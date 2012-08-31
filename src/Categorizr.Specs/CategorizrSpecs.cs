using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Machine.Specifications;

namespace Categorizr.Specs
{
    public class CategorizrSpecs
    {
        [Subject(typeof(Impl.Categorizr))]
        public class when_testing_user_agents
        {
            private static Impl.Categorizr subject;
            private static IEnumerable<CategorizrTest> tests;

            Establish context = () =>
                {
                    subject = new Impl.Categorizr();
                    var useragents = File.ReadAllLines("useragents.csv");
                    var tests = new List<CategorizrTest>();
                    foreach (var useragent in useragents)
                    {
                        var match = Regex.Match(useragent, "^\"(?<ua>[^\"]*)\",(?<expected>[\\w]+)$");
                        tests.Add(new CategorizrTest
                        {
                            Expected = (DeviceCategory)Enum.Parse(typeof(DeviceCategory), match.Groups["expected"].Value),
                            UserAgent = match.Groups["ua"].Value
                        });
                    }
                    when_testing_user_agents.tests = tests;
                };

            Because of = () =>
                {
                    foreach (var test in tests)
                    {
                        test.Actual = subject.Detect(test.UserAgent).Category;
                    }
                };

            It should_detect_correctly = () =>
                {
                    foreach (var test in tests)
                    {
                        test.Verify();
                    }
                };
        }

        [Subject(typeof(Impl.Categorizr))]
        public class when_categorizing_tablets_as_desktop
        {
            private static Impl.Categorizr subject;
            private static DeviceInformation result;

            Establish context = () => subject = new Impl.Categorizr(new CategorizrOptions {CategorizeTabletsAsDesktops = true});

            Because of = () => result = subject.Detect("Mozilla/4.0 (compatible; Linux 2.6.10) NetFront/3.3 Kindle/1.0 (screen 600x800)");

            It should_be_desktop = () => result.Category.ShouldEqual(DeviceCategory.Desktop);
        }

        [Subject(typeof(Impl.Categorizr))]
        public class when_categorizing_tvs_as_desktop
        {
            private static Impl.Categorizr subject;
            private static DeviceInformation result;

            Establish context = () => subject = new Impl.Categorizr(new CategorizrOptions {CategorizeTvsAsDesktops = true});

            Because of = () => result = subject.Detect("Mozilla/5.0 (X11; U; Linux i686; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.127 Large Screen Safari/533.4 GoogleTV/b54202");

            It should_be_desktop = () => result.Category.ShouldEqual(DeviceCategory.Desktop);
        }
    }

    public class CategorizrTest
    {
        public string UserAgent { get; set; }
        public DeviceCategory Expected { get; set; }
        public DeviceCategory Actual { get; set; }
        public void Verify()
        {
            if (Actual != Expected)
            {
                throw new SpecificationException(string.Format(@"User-Agent: {0}
Expected: [{1}]
But was:  [{2}]", UserAgent, Expected, Actual));
            }
        }
    }
}