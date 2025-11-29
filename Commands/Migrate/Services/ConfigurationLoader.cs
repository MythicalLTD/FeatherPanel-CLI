using System.IO;
using FeatherCli.Commands.Migrate.Models;
using FeatherCli.Commands.Migrate.Utils;

namespace FeatherCli.Commands.Migrate.Services;

public class ConfigurationLoader
{
    public PterodactylConfig LoadFromEnvFile(string envFilePath)
    {
        if (!File.Exists(envFilePath))
        {
            throw new FileNotFoundException($"Environment file not found: {envFilePath}");
        }

        var envVars = EnvFileParser.ParseEnvFile(envFilePath);
        
        return new PterodactylConfig
        {
            // Application settings
            AppKey = EnvFileParser.GetValue(envVars, "APP_KEY"),
            AppTimezone = EnvFileParser.GetValue(envVars, "APP_TIMEZONE"),
            AppDebug = EnvFileParser.GetValue(envVars, "APP_DEBUG"),

            // Database settings
            DbConnection = EnvFileParser.GetValue(envVars, "DB_CONNECTION"),
            DbHost = EnvFileParser.GetValue(envVars, "DB_HOST"),
            DbPort = EnvFileParser.GetValue(envVars, "DB_PORT"),
            DbDatabase = EnvFileParser.GetValue(envVars, "DB_DATABASE"),
            DbUsername = EnvFileParser.GetValue(envVars, "DB_USERNAME"),
            DbPassword = EnvFileParser.GetValue(envVars, "DB_PASSWORD"),

            // Hashids settings
            HashidsSalt = EnvFileParser.GetValue(envVars, "HASHIDS_SALT"),
            HashidsLength = EnvFileParser.GetValue(envVars, "HASHIDS_LENGTH"),

            // Mail settings
            MailMailer = EnvFileParser.GetValue(envVars, "MAIL_MAILER"),
            MailHost = EnvFileParser.GetValue(envVars, "MAIL_HOST"),
            MailPort = EnvFileParser.GetValue(envVars, "MAIL_PORT"),
            MailUsername = EnvFileParser.GetValue(envVars, "MAIL_USERNAME"),
            MailPassword = EnvFileParser.GetValue(envVars, "MAIL_PASSWORD"),
            MailEncryption = EnvFileParser.GetValue(envVars, "MAIL_ENCRYPTION"),
            MailFromAddress = EnvFileParser.GetValue(envVars, "MAIL_FROM_ADDRESS"),
            MailFromName = EnvFileParser.GetValue(envVars, "MAIL_FROM_NAME"),

            // Service settings
            AppServiceAuthor = EnvFileParser.GetValue(envVars, "APP_SERVICE_AUTHOR"),
            PterodactylTelemetryEnabled = EnvFileParser.GetValue(envVars, "PTERODACTYL_TELEMETRY_ENABLED")
        };
    }
}

