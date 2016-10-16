
(function () {
    'use strict';
    angular.module('retroApp', [])
        .controller('RetroController', function ($scope, $http) {
            var retrospect = this;

            //Page vars
            retrospect.Name = [""];
            retrospect.Summary = [""];
            retrospect.Date = [""];
            retrospect.Participants = [];
            retrospect.allretro = [];
            retrospect.result = [""];
            // feedback
            retrospect.FeedbackRetroName = [""];
            retrospect.FeedbackName = [""];
            retrospect.FeedbackBody = [""];
            retrospect.FeedbackType = [""];


            retrospect.Submit = function () {
                $http.post('http://localhost:50420/Api/Retrospective',
                    { params: { Name: retrospect.Name, Summary:retrospect.Summary, Date: retrospect.Date,Participants:retrospect.Participants } }).
                   success(function (data, status, headers, config) {
                       retrospect.allretro = data;
                       retrospect.result = "Success";

                   });
            };

            retrospect.Feedback = function () {
                $http.put('http://localhost:50420/Api/Retrospective',
                    { params: { RetroName: retrospect.FeedbackRetroName, Name: retrospect.FeedbackName, Body: retrospect.FeedbackBody, FeedbackType: retrospect.FeedbackType } }).
                   success(function (data, status, headers, config) {
                       retrospect.allretro = data;
                       retrospect.result = "Success";

                   });
            };

            // show all retrospectives
            retrospect.ShowAll = function () {
                $http.get('http://localhost:50420/Api/Retrospective').
                    success(function (data, status, headers, config) {
                        retrospect.allretro = data;
                        retrospect.result = "Success";
                    })
                //need failure code too
            };

            //get by date 
            retrospect.ShowByDate = function () {

                $http.get('http://localhost:50420/Api/Retrospective', { params: { Date: retrospect.SearchDate } }).
                    success(function (data, status, headers, config) {
                        retrospect.allretro = data;
                        retrospect.result = "Success";

                    });
            };

            // add participant to retrospective
            retrospect.addParticipant = function () {
                retrospect.Participants.push({ text: retrospect.ParticipantName, done: false });
                retrospect.ParticipantName = '';
            };

        });
})();


