// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailspin.Surveys.Data.DataModels
{
    public enum QuestionType
    {
        SimpleText,
        MultipleChoice,
        FiveStars
    }

    [RequiredAnswer(ErrorMessage = "* Answers must be supplied for the question.")]
    public class Question
    {
        public Question()
        {
            this.Type = QuestionType.SimpleText;
        }
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Survey Survey { get; set; }
        public Tenant Tenant { get; set; }
        public Guid SurveyId { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Text { get; set; }

        public QuestionType Type { get; set; }

        [Display(Name = "Answer Choices")]
        public string PossibleAnswers { get; set; }











    }
}