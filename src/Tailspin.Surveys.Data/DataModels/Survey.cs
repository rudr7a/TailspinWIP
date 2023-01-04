// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailspin.Surveys.Data.DataModels
{
    public class Survey
    {

        public Survey() : this(string.Empty)
        {
        }
        public Survey(string title)
        {
            Title = title;
        }

        [Required(ErrorMessage = "* You must provide a Title for the survey.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public bool Published { get; set; }
        public Guid Id { get; set; }

        public User Tenant { get; set; }
        public User Owner { get; set; }
        public Guid OwnerId { get; set; }

        public Guid TenantId { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<SurveyContributor> Contributors { get; set; }
        public ICollection<ContributorRequest> ContributerRequests { get; set; }








    }
}
