(function ($) {
    var questionService = abp.services.app.question,
        _$voteUpLink = $('#voteUpLink'),
        _$voteDownLink = $('#voteDownLink'),
        _$submitAnswerButton = $('#submitAnswer'),
        _$acceptAnswerButton = $('.acceptAnswer'),
        _$answerTextarea = $('#answerTextarea'),
        _$questionId = $('#questionId').val(),
        _$modal = $('#QuestionDetailModal');


    var voteUp = function () {
        questionService.voteUp({
            id: _$questionId
        }).done(function (data) {
            abp.notify.info("Saved your vote. Thanks.");
            _$modal.modal('hide');
            location.reload();
    
        });
    };

    var voteDown = function () {
        questionService.voteDown({
            id: _$questionId
        }).done(function (data) {
            abp.notify.info("Saved your vote. Thanks.");
            _$modal.modal('hide');
            location.reload();
        });
    };

    var submitAnswer = function () {
        questionService.submitAnswer({
            questionId: _$questionId,
            text: _$answerTextarea.val(),
        }).done(function () {
            abp.notify.info("Saved your answer. Thanks.");
            answerText = '';
            _$modal.modal('hide');
            location.reload();
        });
    };

    var acceptAnswer = function (answer) {
        questionService.acceptAnswer({
            id: answer.id
        }).done(function () {
            abp.notify.info("You accepted the answer");
            _$modal.modal('hide');

        });
    };

    _$voteUpLink.on('click', voteUp);
    _$voteDownLink.on('click', voteDown);
    _$submitAnswerButton.on('click', submitAnswer);

    _$acceptAnswerButton.on('click', function () {
        var answerId = _$acceptAnswerButton.data('answerid');
        acceptAnswer({ id: answerId });
        console.log(answerId)
    });

})(jQuery);
