// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  baseUrl2: 'https://localhost:44383/',

  basePath : "https://localhost:44383/",
  authPath : "https://localhost:44383/api/Auth",
  userPath : "https://localhost:44383/api/Users",
  quizTakerPath : "https://localhost:44383/api/QuizTakers",
  quizPath : "https://localhost:44383/api/Quizzes",
  questionPath : "https://localhost:44383/api/Questions",
  customerAnswerPath : "https://localhost:44383/api/CustomerAnswers",
  questionOptionPath : "https://localhost:44383/api/QuestionOptions",
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
