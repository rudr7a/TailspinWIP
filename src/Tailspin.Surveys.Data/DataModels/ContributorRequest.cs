// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailspin.Surveys.Data.DataModels
{
    public class ContributorRequest
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Survey Survey { get; set; }
        public Tenant Tenant { get; set; }
        public Guid SurveyId { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

    }
}
