using DeratMain.Models.Callback;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeratMain.Databases.Entities
{
    public class Callback : BaseEntity
    {
        public Callback(CallbackCreateModel callbackCreateModel) : base()
        {
            FullName = callbackCreateModel.FullName;
            Email = callbackCreateModel.Email;
            Services = string.Join(',', callbackCreateModel.Services);
            Phone = callbackCreateModel.Phone;
            DateTime = callbackCreateModel.DateTime;
        }

        public Callback() : base()
        {
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public virtual string Services { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
