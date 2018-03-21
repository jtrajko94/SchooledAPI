using SchooledAPI.Data;
using SchooledAPI.Utilities;
using System.Collections.Generic;

namespace SchooledAPI.Services
{
    public class QuestionService
    {
        public static APIValidatorResponse IsValid(QuestionData question)
        {
            List<string> errors = new List<string>();
            bool isValid = true;

            if(question.TotalAnswers == 4)
            {
                if (!Validator.Item(ValidatorType.AnyValue, question.AnswerOne.ToString())
                    && !Validator.Item(ValidatorType.AnyValue, question.AnswerTwo.ToString())
                    && !Validator.Item(ValidatorType.AnyValue, question.AnswerThree.ToString())
                    && !Validator.Item(ValidatorType.AnyValue, question.AnswerFour.ToString()))
                {
                    isValid = false;
                    errors.Add("Four answers needed.");
                }

                if(!Validator.Item(ValidatorType.Integer, question.CorrectAnswer.ToString()) && question.CorrectAnswer >= 1 && question.CorrectAnswer <= 4)
                {
                    isValid = false;
                    errors.Add("Provide a valid correct answer (i.e. 1-4)");
                }
            }else if (question.TotalAnswers == 3)
            {
                if (!Validator.Item(ValidatorType.AnyValue, question.AnswerOne.ToString())
                    && !Validator.Item(ValidatorType.AnyValue, question.AnswerTwo.ToString())
                    && !Validator.Item(ValidatorType.AnyValue, question.AnswerThree.ToString()))
                {
                    isValid = false;
                    errors.Add("Three answers needed.");
                }

                if (!Validator.Item(ValidatorType.Integer, question.CorrectAnswer.ToString()) && question.CorrectAnswer >= 1 && question.CorrectAnswer <= 3)
                {
                    isValid = false;
                    errors.Add("Provide a valid correct answer (i.e. 1-3)");
                }
            }else if(question.TotalAnswers == 2)
            {
                if (!Validator.Item(ValidatorType.AnyValue, question.AnswerOne.ToString())
                    && !Validator.Item(ValidatorType.AnyValue, question.AnswerTwo.ToString()))
                {
                    isValid = false;
                    errors.Add("Two answers needed.");
                }

                if (!Validator.Item(ValidatorType.Integer, question.CorrectAnswer.ToString()) && question.CorrectAnswer >= 1 && question.CorrectAnswer <= 2)
                {
                    isValid = false;
                    errors.Add("Provide a valid correct answer (i.e. 1-2)");
                }
            }
            else
            {
                isValid = false;
                errors.Add("Invalid total answers. (i.e. 2-4)");
            }

            if (!Validator.Item(ValidatorType.Integer, question.Difficulty.ToString()))
            {
                isValid = false;
                errors.Add("Difficulty is required.");
            }

            if (!Validator.Item(ValidatorType.Integer, question.Question.ToString()))
            {
                isValid = false;
                errors.Add("Question text is required.");
            }

            if(!Validator.Item(ValidatorType.AnyValue, question.CourseRowKey))
            {
                isValid = false;
                errors.Add("Course Id is required.");
            }

            return new APIValidatorResponse { IsValid = isValid, Errors = errors };
        }
    }
}