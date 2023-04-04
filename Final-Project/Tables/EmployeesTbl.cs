using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project.Tables
{
    public class EmployeesTbl
    {
        protected int EId;
        protected string EName;
        protected string EPhone;
        protected string EGen;
        protected string EAdd;
        protected string EPass;
        public EmployeesTbl(int EId,string EName, string EPhone, string EGen, string EAdd, string EPass)
        {
            this.EId = EId;
            this.EName = EName;
            this.EPhone = EPhone;
            this.EGen = EGen;
            this.EAdd = EAdd;
            this.EPass = EPass;
        }
        public int Id {get => EId;}
        public string Name {get => EName;}
        public string Phone {get => EName;}
        public string Gen {get => EGen;}
        public string Add {get => EAdd;}
        public string Pass {get => EPass;}


    }
}
