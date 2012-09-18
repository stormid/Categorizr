require 'albacore'
require 'fileutils'

task :build => ['build:specs']

namespace :build do
	msbuild :msbuild, [:target, :options] => :clean do |msb, args|
		msbuild_options = args[:options] || {}
		msb.targets [:clean, :rebuild]
		msb.properties = msbuild_options.merge({
			:configuration => args[:target] || :Debug,
			:outdir => "#{Dir.pwd}/build/"
		})
		msb.verbosity = "minimal"
		msb.solution = "Categorizr.sln"
	end
	
	mspec :specs => :msbuild do |mspec|
		mspec.command = "packages/Machine.Specifications.0.5.8/tools/mspec-clr4.exe"
		mspec.assemblies "build/Categorizr.Specs.dll"
	end
end

task :clean do
	FileUtils.rm_rf("build") if File.directory? "build"
end

task :publish do

end