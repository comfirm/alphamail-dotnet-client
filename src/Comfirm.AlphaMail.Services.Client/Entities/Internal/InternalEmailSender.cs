﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Comfirm.AlphaMail.Services.Client.Entities.Internal
{
    [DataContract]
    internal class InternalEmailSender
    {
        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string name { get; set; }
    }
}
