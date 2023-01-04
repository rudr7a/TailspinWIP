// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tailspin.Surveys.Data.DataModels
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<Survey> Surveys { get; set; }

        public string IssuerValue { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    }
}
