/* 
 *      Name:           CTS - Contact Tracking System 
 *      Description:    This class is product data model
 *      Author:         Wenhui Fan
 *      Created:        2024/09/26
 *      Last Updated:   2024/09/28
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace cts_app.Data.Data.Models
{
    public partial class Candidate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ZipCode { get; set; }

    }
}
