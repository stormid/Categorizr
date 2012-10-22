require 'albacore'
require 'fileutils'

task :default => :build

task :build => ['build:specs']

namespace :build do
	msbuild :compile, [:target] => ['clean:build'] do |msb, args|
		msb.targets [:clean, :rebuild]
		msb.properties = {
			:configuration => args[:target] || :Debug,
			:outdir => "#{Dir.pwd}/build/"
		}
		msb.verbosity = "minimal"
		msb.solution = "Categorizr.sln"
	end
	
	mspec :specs => :compile do |mspec|
		mspec.command = "packages/Machine.Specifications.0.5.8/tools/mspec-clr4.exe"
		mspec.assemblies "build/Categorizr.Specs.dll"
	end
end

namespace :clean do
	task :build do
		rm_rf("build") if File.directory? "build"
	end
	
	task :release do
		rm_rf("release") if File.directory? "release"
	end
end

task :publish, [:apikey] => ['build', 'clean:release'] do |task, args|
	Rake::Task['build:compile'].execute({:target => :Release})
	mkdir_p("release/lib/net20")
	cp "build/Categorizr.dll", "release/lib/net20"
	Rake::Task['nuget:create'].invoke
	Rake::Task['nuget:pack'].invoke
	Rake::Task['nuget:push'].invoke(args.apikey)
end

namespace :nuget do
	nuspec :create do |nuspec|
		nuspec.id = "Categorizr"
		nuspec.version = "0.1.1"
		nuspec.authors = "Rory Fitzpatrick"
		nuspec.description = "A modern device detection script"
		nuspec.title = "Categorizr"
		nuspec.projectUrl = "https://github.com/stormid/Categorizr"
		nuspec.tags = "mobile device-detection"
		nuspec.working_directory = "release"
		nuspec.output_file = "Categorizr.nuspec"
		nuspec.copyright = "Rory Fitzpatrick 2012, Brett Jankford 2011"
	end
	
	nugetpack :pack do |nuget|
		nuget.command = ".nuget/Nuget.exe"
		nuget.nuspec = "release/Categorizr.nuspec"
		nuget.base_folder = "release"
		nuget.output = "release"
	end
	
	nugetpush :push, [:apikey] do |nuget, args|
		nuget.command = ".nuget/Nuget.exe"
		nuget.package = "release\\Categorizr.0.1.1.nupkg"
		nuget.apikey = args.apikey
	end
end