using MaintenanceDashbord.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MaintenanceDashbord.Tests.UnitTests
{

    [TestClass]
    public class ObsevableObjectTests
    {
        [TestMethod]
        public void PropertyChangedEventHendlerIsRaised()
        {
            var obj = new TestObservableObject();

            bool raised = false;

            //Called event
            obj.PropertyChanged += (sender, e) =>
                                    {
                                        Assert.IsTrue(e.PropertyName == "ChangedProperty");
                                        raised = true;
                                   };
            
            obj.ChangedProperty = "Some Value";

            if (raised==false) Assert.Fail("PropertyChanged was never invoked");
        }

    }

    class TestObservableObject:ObservableObject
    {
        private string changedProperty;
        
        public string ChangedProperty
        {
            get { return changedProperty; }
            set 
            {
                changedProperty = value;
                NotifyPropertyChanged(); //The method used [CallerMemberName]  injects the property name as a parameter
            }
        }
    }
}
