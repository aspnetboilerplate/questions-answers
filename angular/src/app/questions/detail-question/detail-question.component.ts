import { Component, Injector, OnInit,Output, EventEmitter, } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { QuestionServiceProxy, QuestionDto, SubmitAnswerInput, QuestionWithAnswersDto, AnswerDto } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { threadId } from 'worker_threads';

@Component({
  selector: 'app-question-detail',
  templateUrl: './detail-question.component.html',
  styleUrls: ['./detail-question.component.less']
})


export class DetailQuestionComponent extends AppComponentBase implements OnInit {
  question: QuestionWithAnswersDto;
  answerText: string = '';
  ownQuestion: boolean = false;
  id:number;
  answer: AnswerDto;

  @Output() onSave = new EventEmitter<any>();
  constructor(
    injector: Injector,
    private questionService: QuestionServiceProxy,
    private route: ActivatedRoute,
    private bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
      if (this.id) {
        this.loadQuestionWithAnswers(true, this.id);
      }
  }

  voteUp(questionDto: QuestionDto): void {
    this.questionService.voteUp(questionDto)
      .subscribe((data: any) => {
        this.question.voteCount = data.voteCount;
        this.bsModalRef.hide();
      });
  }

  voteDown(questionDto: QuestionDto): void {
    this.questionService.voteDown(questionDto)
      .subscribe((data: any) => {
        this.question.voteCount = data.voteCount;
        this.bsModalRef.hide();
      });
  }

  submitAnswer(): void {
    const submitInput: SubmitAnswerInput = new SubmitAnswerInput(); 
    submitInput.questionId = this.question.id;
    submitInput.text = this.answerText;
  
    this.questionService.submitAnswer(submitInput).subscribe((data: any) => {
      this.question.answers.push(data.answer);
      this.answerText = '';
      this.bsModalRef.hide();
      this.onSave.emit();
    });
  }
  


  acceptAnswer(answer: any): void {
    this.questionService.acceptAnswer(answer)
      .subscribe(() => {
        // handle success
      });
  }

  private loadQuestionWithAnswers(incrementViewCount: boolean, id?: number): void {
    this.questionService.getQuestion(incrementViewCount, id).subscribe((data: any) => {
      this.question = data.question;
  
      
      const acceptedAnswerIndex = this.question.answers.findIndex((answer: any) => answer.isAccepted);
      if (acceptedAnswerIndex > 0) {
        const acceptedAnswer = this.question.answers[acceptedAnswerIndex];
        this.question.answers.splice(acceptedAnswerIndex, 1);
        this.question.answers.unshift(acceptedAnswer);
      }
    });
  }

  cancel(): void {
    this.bsModalRef.hide();
  }
}
