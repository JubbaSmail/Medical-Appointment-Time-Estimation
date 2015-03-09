
namespace EstimationBasedOnFactors
{
    public class MembershipFunction
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string value;
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public MembershipFunction(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}