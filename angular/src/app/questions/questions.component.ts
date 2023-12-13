import { Component, Injector } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CreateQuestionDialogComponent } from './create-question/create-question-dialog.component';
import {QuestionServiceProxy,QuestionDtoPagedResultDto,QuestionDto } from '@shared/service-proxies/service-proxies';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DetailQuestionComponent } from './detail-question/detail-question.component';


class PagedQuestionsRequestDto extends PagedRequestDto{
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-question',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.less'],
  animations: [appModuleAnimation()]
})
export class QuestionComponent extends PagedListingComponentBase<QuestionDto> {
  permissions: any;
  sortingDirections: string[] = ['CreationTime DESC', 'VoteCount DESC', 'ViewCount DESC', 'AnswerCount DESC'];
  questions: QuestionDto[] = [];
  totalQuestionCount: number = 0;
  sorting: string = 'CreationTime DESC';
  keyword = '';
  isActive: boolean | null;

  constructor(
    injector: Injector,
    private _questionService: QuestionServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }


 

  list(request:PagedQuestionsRequestDto,pageNumber:number,finishedCallback:Function): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;
    
    const skipCount = pageNumber ? this.questions.length : 0;

    
    this._questionService.getQuestions(
      this.totalQuestionCount,
      skipCount,
      this.sorting).subscribe((data: any) => {
      if (skipCount) {
        this.questions.push(...data.items);
      } else {
        this.questions = data.items;
      }
      this.totalQuestionCount = data.totalCount;
    });
  }

  delete(question:QuestionDto):void{

  }

  createQuestion():void{
    this.showCreateQuestionDialog();
    
  }

  private showCreateQuestionDialog(id?:number): void {
    let modalRef: BsModalRef;
    modalRef = this._modalService.show(
      CreateQuestionDialogComponent,
      {
        class:"modal-lg",
      }
    );

    modalRef.content.onSave.subscribe(()=>{
      this.refresh();
    })
  }

  getQuestion(question:QuestionDto){
    this.showGetQuestionDialog(question.id);
  }

  private showGetQuestionDialog(id?:number):void{
    let modalRef: BsModalRef;
    modalRef = this._modalService.show(
      DetailQuestionComponent,
      {
        class:"modal-lg",
        initialState: {
          id:id,
        }
      }
    )
  }

}

  