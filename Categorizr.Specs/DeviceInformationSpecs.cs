using Machine.Specifications;

namespace Categorizr.Specs
{
    public class DeviceInformationSpecs
    {
        [Subject(typeof(DeviceInformation))]
        public class when_category_is_desktop
        {
            private static DeviceInformation subject;
            private static bool result;

            Establish context = () => subject = new DeviceInformation(DeviceCategory.Desktop);

            Because of = () => result = subject.IsDesktop;

            It should_be_desktop = () => result.ShouldBeTrue();
        }

        [Subject(typeof(DeviceInformation))]
        public class when_category_is_mobile
        {
            private static DeviceInformation subject;
            private static bool result;

            Establish context = () => subject = new DeviceInformation(DeviceCategory.Mobile);

            Because of = () => result = subject.IsMobile;

            It should_be_mobile = () => result.ShouldBeTrue();
        }

        [Subject(typeof(DeviceInformation))]
        public class when_category_is_tablet
        {
            private static DeviceInformation subject;
            private static bool result;

            Establish context = () => subject = new DeviceInformation(DeviceCategory.Tablet);

            Because of = () => result = subject.IsTablet;

            It should_be_tablet = () => result.ShouldBeTrue();
        }

        [Subject(typeof(DeviceInformation))]
        public class when_category_is_tv
        {
            private static DeviceInformation subject;
            private static bool result;

            Establish context = () => subject = new DeviceInformation(DeviceCategory.Tv);

            Because of = () => result = subject.IsTv;

            It should_be_tv = () => result.ShouldBeTrue();
        }
    }
}