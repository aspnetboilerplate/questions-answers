(function ($) {
    var _questionService = abp.services.app.question,
        _$modal = $('#QuestionCreateModal'),
        _$form = _$modal.find('form'),
        $sortAsc = $('#sortAsc'),
        $sortDesc = $('#sortDesc'),
        $showMoreBtn = $('#showMoreBtn');


    var questions = [];
    var sorting = 'CreationTime DESC';

    function loadQuestions(append) {
        var skipCount = append ? questions.length : 0;
              
        abp.ui.setBusy(
            null,
            _questionService.getQuestions({
                skipCount: skipCount,
                sorting: sorting
            }).done(function (data) {
                if (append) {
                    for (var i = 0; i < data.items.length; i++) {
                        questions.push(data.items[i]);
                        appendQuestionToDom(data.items[i]);
                    }
                } else {
                    questions = data.items;
                    renderQuestionsToDom();
                }
                totalQuestionCount = data.totalCount;
            })
        );
    }

    function appendQuestionToDom(question) {
        var questionList = $('#QuestionList');
        var questionHtml = createQuestionHtml(question);
        questionList.append(questionHtml);
    }

    function renderQuestionsToDom() {
        var questionList = $('#QuestionList');
        questionList.empty(); 

        if (questions.length == 0) {
            questionList.append('<div class="col-xs-12 text-center">' + abp.localization.localize('ThereAreNoQuestionsToShow') + '</div>');
            return;
        }
        
        for (var i = 0; i < questions.length; i++) {
            var questionHtml = createQuestionHtml(questions[i]);
            questionList.append(questionHtml);
        }
    }

    function createQuestionHtml(question) {
        var formattedDate = new Date(question.creationTime).toLocaleString(undefined, {
            year: 'numeric',
            month: 'numeric',
            day: 'numeric',
            hour: '2-digit',
            minute: '2-digit'
        });
        var html = '<div class="row question">' +
            '<div class="vote-count col-sm-1 hidden-xs">' +
            '<div>' + question.voteCount + '</div>' +
            '<div>votes</div>' +
            '</div>' +
            '<div class="answer-count col-sm-1 hidden-xs">' +
            '<div>' + question.answerCount + '</div>' +
            '<div>answers</div>' +
            '</div>' +
            '<div class="view-count col-sm-1 hidden-xs">' +
            '<div>' + question.viewCount + '</div>' +
            '<div>views</div>' +
            '</div>' +
            '<div class="summary col-xs-12 col-sm-9">' +
            '<h3>' +
            '<a href="#" class="question-link" data-question-id="' + question.id + '" data-toggle="modal" data-target="#QuestionDetailModal">' +
            '<span class="question-id">' + "#" + question.id + '</span> <span>' + question.title + '</span>' +
            '</a>' +
            '</h3>' +
            '<div>' +
            '<span>' + question.creatorUserName + '</span>,' +
            '<span class="text-muted formatted-date">' + formattedDate + '</span>' +
            '</div>' +
            '</div>' +
            '</div>';
        return html;
    }

    function sort(sortingDirection) {
        sorting = sortingDirection;
        loadQuestions();
    }

    function showMore() {
        loadQuestions(true);
    }

    $sortAsc.on('click', function () {
        sort('CreationTime Asc');
    });

    $sortDesc.on('click', function () {
        sort('CreationTime Desc');
    });

    $showMoreBtn.on('click', function () {
        showMore();
    });

    _$form.validate({
        rules: {

        }
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var question = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _questionService.createQuestion(question).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info('Saved Successfully');
            loadQuestions();

        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $(document).on('click', '.question-link',function (e) {
        e.preventDefault();
        var questionId = $(this).data('question-id');

        if (!questionId) {
            console.error("Question ID is missing.");
            return;
        }

        abp.ajax({
            url: abp.appPath + 'Question/EditModal?questionId=' + questionId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#QuestionDetailModal div.modal-content').html(content);
                
            },
            error: function (e) {
                console.error("Ajax request failed:", e);
            }
        });
    });

    
    loadQuestions();

})(jQuery);
