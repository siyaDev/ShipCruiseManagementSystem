using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipCruiseManagementSystem.Models
{
   public class ActionResult
    {

        /// <summary>
        /// Was the request successful
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// A message for failure or information
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The Id of the model being used
        /// </summary>
        public int ModelId { get; set; }
        /// <summary>
        /// Indicates whether the failure was expected or a technical issue which is not expected.
        /// </summary>
        public bool TechnicalIssue { get; set; }
    }
}
