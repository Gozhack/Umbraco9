﻿namespace Umbraco.Core.Models
{
    public interface IDomain
    {
        int? LanguageId { get; set; }
        string DomainName { get; set; }
        int? RootContentId { get; set; }
        bool IsWildcard { get; }

        /// <summary>
        /// Readonly value of the language ISO code for the domain
        /// </summary>
        string LanguageIsoCode { get; }
    }
}