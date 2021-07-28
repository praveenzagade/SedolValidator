using MnG.SedolChecker.Common;
using MnG.SedolChecker.Interfaces;

namespace MnG.SedolChecker.Implementations
{
    public class ImplementedSedolValidator : ISedolValidator
    {
        private readonly IInputValidator _InputLengthValidator;
        private readonly IInputValidator _InputContentValidator;
        private readonly IInputValidator _InputCheckSumValidator;
        private readonly IInputValidator _UserDefinedSedolValidator;
        private readonly IDataCleaner _InputDataCleaner;

        public ImplementedSedolValidator()
        {
            IValueProvider alphabetCodeValueProvider = new AlphabetCodeValueProvider();
            IValueProvider codeValueProvider = new CodeValueProvider(alphabetCodeValueProvider);
            IWeightingFactorProvider weightingFactorProvider = new HardCodedWeightingFactorProvider();

            ICheckSumProvider checkSumProvider = new CheckSumProvider(codeValueProvider,
                                                                      weightingFactorProvider);
            _InputCheckSumValidator = new InputCheckSumValidator(checkSumProvider);

            _InputLengthValidator = new InputLengthValidator();
            _InputContentValidator = new InputContentValidator();
            _UserDefinedSedolValidator = new UserDefinedSedolValidator();
            _InputDataCleaner = new InputDataCleaner();
        }

        /// <summary>
        /// Constructor provided for Constructor injection
        /// </summary>
        /// <param name="inputDataCleaner"></param>
        /// <param name="inputLengthValidator"></param>
        /// <param name="inputContentValidator"></param>
        /// <param name="inputCheckSumValidator"></param>
        /// <param name="userDefinedSedolValidator"></param>
        public ImplementedSedolValidator(IDataCleaner inputDataCleaner,
                                         IInputValidator inputLengthValidator,
                                         IInputValidator inputContentValidator,
                                         IInputValidator inputCheckSumValidator,
                                         IInputValidator userDefinedSedolValidator)
        {
            _InputDataCleaner = inputDataCleaner;
            _InputLengthValidator = inputLengthValidator;
            _InputContentValidator = inputContentValidator;
            _InputCheckSumValidator = inputCheckSumValidator;
            _UserDefinedSedolValidator = userDefinedSedolValidator;
        }

        public ISedolValidationResult ValidateSedol(string input)
        {
            string cleanedInput = _InputDataCleaner.Clean(input);
            bool isValidSedol = false;
            bool isUserDefined = false;
            string validationDetails = null;
            if (_InputLengthValidator.IsValid(cleanedInput))
            {
                if (_InputContentValidator.IsValid(cleanedInput))
                {
                    isValidSedol = _InputCheckSumValidator.IsValid(cleanedInput);
                    isUserDefined = _UserDefinedSedolValidator.IsValid(cleanedInput);
                    if (!isValidSedol)
                    {
                        validationDetails = ErrorMessages.CheckSumError;
                    }
                }
                else
                {
                    validationDetails = ErrorMessages.ContainsInvalidChar;
                }
            }
            else
            {
                validationDetails = ErrorMessages.InputStringNot7CharLong;
            }

            return new SedolValidationResult(inputString: input,
                                             isValidSedol: isValidSedol,
                                             isUserDefined: isUserDefined,
                                             validationDetails: validationDetails);
        }
    }
}