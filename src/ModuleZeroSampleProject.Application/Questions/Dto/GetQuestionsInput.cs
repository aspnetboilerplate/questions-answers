using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;

namespace ModuleZeroSampleProject.Questions.Dto
{
    public class GetQuestionsInput :  IPagedResultRequest, ISortedResultRequest
    {
        [Range(0, 1000)]
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Sorting { get; set; }

  
    }
}