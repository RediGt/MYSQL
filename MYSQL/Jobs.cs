using System;
using System.Collections.Generic;
using System.Text;

namespace MYSQL
{
    class Jobs
    {
        public string jobName;
        public string jobDescr;

        public Jobs(string jobName, string jobDescr)
        {
            this.jobName = jobName;
            this.jobDescr = jobDescr;
        }
    }
}
