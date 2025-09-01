using System;
using System.Collections.Generic;

namespace onlizas.Entities
{
    public enum SectionStatus { Draft, Published }

    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string TargetingRule { get; set; }
        public bool Enabled { get; set; }
        public SectionStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<SectionProduct> SectionProducts { get; set; } = new List<SectionProduct>();
        public ICollection<SectionBanner> SectionBanners { get; set; } = new List<SectionBanner>();
        public ICollection<SectionCriterion> SectionCriteria { get; set; } = new List<SectionCriterion>();
        public ICollection<SectionVersion> SectionVersions { get; set; } = new List<SectionVersion>();
    }

    public class SectionProduct
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public Guid ProductGlobalId { get; set; }
    }

    public class SectionBanner
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public Guid BannerGlobalId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int Priority { get; set; }
    }

    public class SectionCriterion
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public Guid CriterionGlobalId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class SectionVersion
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public DateTime ChangedAt { get; set; }
        public string ChangedBy { get; set; }
        public string ChangeSummary { get; set; }
        public string DataSnapshot { get; set; }
    }
}