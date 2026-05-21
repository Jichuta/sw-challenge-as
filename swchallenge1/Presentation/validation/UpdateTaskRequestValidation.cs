using swchallenge1.Presentation.Dtos;

namespace swchallenge1.Presentation.validation;

public static class UpdateTaskRequestValidation
{
    public static bool Validate(UpdateTaskRequest request, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            errorMessage = "Title is required.";
            return false;
        }

        return true;
    }
}