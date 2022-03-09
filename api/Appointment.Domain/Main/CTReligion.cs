﻿using System;
using System.Collections.Generic;

namespace Appointment.Domain.Main
{
    public class CTReligion
    {
        public Guid ReligionId { get; set; }
        public string Code { get; set; }
        public string DisplayValue { get; set; }
        public string Description { get; set; }
        public bool IsUserMaintainable { get; set; }
        public int SortOrder { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
