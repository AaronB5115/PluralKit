namespace Myriad.Types;

public record InteractionResponse
{
    public enum ResponseType
    {
        Pong = 1,
        ChannelMessageWithSource = 4,
        DeferredChannelMessageWithSource = 5,
        DeferredUpdateMessage = 6,
        UpdateMessage = 7,
        AutocompleteResult = 8,
        Modal = 9,
    }

    public ResponseType Type { get; init; }
    public InteractionApplicationCommandCallbackData? Data { get; init; }
}