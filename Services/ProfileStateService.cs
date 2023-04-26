using Fyp.API;

namespace FinalYearProjectWasmPortal.Services;

public class ProfileStateService
{
    private IProfileClient _profileClient;
    private ProfileInfo? _profileInfo;

    public ProfileStateService(IProfileClient profileClient)
    {
        _profileClient = profileClient;
    }

    public event Action? OnChange;

    public async Task<ProfileInfo?> GetProfileInfo()
    {
        if (_profileInfo != null) return _profileInfo;
        var profileFromApi = await _profileClient.GetProfileAsync();
        _profileInfo = new ProfileInfo { ProfileDetails = profileFromApi.Data.ProfileDetails };

        return _profileInfo;
    }

    public async Task UpdateProfileInfoAsync(ProfileInfo profileInfo)
    {
        _profileInfo = profileInfo;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}