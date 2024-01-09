using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers.Questions.Dto
{
    public class GetQuestionsInput : IPagedResultRequest, ISortedResultRequest
    {
        [Range(0, 1000)]
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Sorting { get; set; }


    }
}
