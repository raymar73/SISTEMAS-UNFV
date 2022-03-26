using System;

namespace ExternalServices.GoogleCaptcha
{
    public interface ICaptchaGoogleService
    {
        Boolean ValidateCaptcha(string token);
    }
}
