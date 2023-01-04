// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

namespace Tailspin.Surveys.Data.DataModels
{
    public class SurveyContributor
    {
        public Guid Id { get; set; }

        public Guid SurveyId { get; set; }
        public Guid TenantId { get; set; }
        public Survey Survey { get; set; }
        public Tenant Tenant { get; set; }




    }
}
