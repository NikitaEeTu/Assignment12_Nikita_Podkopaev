using System.Configuration;

namespace Assignment_12
{
    public partial class Form1 : Form
    {
        private class Employee
        {
            private string name;
            private long empNumber;

            public Employee(string name, long empNumber)
            {
                this.name = name;
                this.empNumber = empNumber;
            }

            public void setName(string name)
            {
                this.name = name;
            }

            public void setEmpNumber(long empNumber)
            {
                this.empNumber = empNumber;
            }

            public string getName()
            {
                return this.name;
            }

            public long getEmpNumber()
            {
                return this.empNumber;
            }
        }

        private class ProductionWorker : Employee{
            private int shiftNumber;
            private double hourPayRate;

            public ProductionWorker(string name, long empNumber, int shiftNumber, double hourPayRate) : base(name, empNumber)
            {
                this.shiftNumber = shiftNumber;
                this.hourPayRate = hourPayRate;
            }

            public void setshiftNumber(int shiftNumber)
            {
                this.shiftNumber = shiftNumber;
            }

            public void sethourPayRate(double hourPayRate)
            {
                this.hourPayRate = hourPayRate;
            }

            public int getShiftNumber()
            {
                return this.shiftNumber;
            }
            
            public double getHourPayRate()
            {
                return this.hourPayRate;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string empName = textBox1.Text;
            long empNumber = checkForInteger(textBox2.Text);

            Employee newEmployee = new Employee(empName, empNumber);

            textBox5.AppendText(String.Format("Employee has been created with name {0} and number {1}" + Environment.NewLine, newEmployee.getName(), newEmployee.getEmpNumber()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string empName = textBox1.Text;
            long empNumber = checkForInteger(textBox2.Text);
            int shiftNumber = checkForInteger(textBox3.Text);
            double hourPayRate = checkForLong(textBox4.Text);

            ProductionWorker productionWorker = new ProductionWorker(
                empName,
                empNumber,
                shiftNumber,
                hourPayRate
                );

            string shiftName = getNameOfTheShift(shiftNumber);
            string status = checkTheArguments(productionWorker);

            textBox6.Text = status;

            textBox5.AppendText(String.Format("Production Worker has been created with name: {0}, number: {1}, shift: {2} hour pay rate: {3}", productionWorker.getName(), productionWorker.getEmpNumber(), shiftName, productionWorker.getHourPayRate()));
        }

        private string checkTheArguments(ProductionWorker worker)
        {
            string empName = worker.getName();
            long empNumber = worker.getEmpNumber();
            int shiftNumber = worker.getShiftNumber();
            double hourPayRate = worker.getHourPayRate();
            if (empName.Equals("") && empNumber.Equals("") && shiftNumber.Equals("") && hourPayRate.Equals(""))
            {
                return "OK";
            }
            else
            {
                return "Some fields are empty";
            }
        }

        private int checkForInteger(string number)
        {
            try
            {
                int checkedNumber = Int32.Parse(number);
                return checkedNumber;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        private long checkForLong(string number)
        {
            try
            {
                long checkedNumber = Int64.Parse(number);
                return checkedNumber;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private string getNameOfTheShift(int shiftNumber)
        {
            if(shiftNumber == 1)
            {
                return "shift";

            }
            else if(shiftNumber == 2)
            {
                return "night shift";
            }
            else
            {
                return "shift";
            }
        }
    }
}