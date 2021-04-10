using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultivoPina.Core
{
    public class OperationResult
    {
        public OperationResult()
        {
            this.Errors = new List<string>().AsReadOnly();
            this.Succeeded = false;
        }

        public OperationResult(IEnumerable<string> errors)
            : this()
        {
            this.Errors = errors.ToList().AsReadOnly();
        }

        public OperationResult(bool succeeded)
            : this()
        {
            this.Succeeded = succeeded;

        }

        //
        // Summary:
        //     List of errors
        public IEnumerable<string> Errors { get; private set; }

        //
        // Summary:
        //     True if the operation was successful
        public bool Succeeded { get; private set; }
    }
}

