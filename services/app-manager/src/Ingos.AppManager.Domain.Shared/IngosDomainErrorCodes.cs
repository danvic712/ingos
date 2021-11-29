namespace Ingos.AppManager.Domain.Shared
{
    public static class IngosDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */

        #region Application Modules

        public const string ApplicationNameIsEmpty = "Ingos:Applications:000001";

        public const string ApplicationWithSameNameExists = "Ingos:Applications:000002";

        #endregion
    }
}