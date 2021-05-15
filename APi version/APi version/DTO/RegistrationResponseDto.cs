using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APi_version.DTO
{
        public class RegistrationResponseDto
        {
            public bool IsSuccessfulRegistration { get; set; }
            public IEnumerable<string> Errors { get; set; }
        }
    
}
