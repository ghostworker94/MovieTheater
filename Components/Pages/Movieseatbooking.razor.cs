using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorÖvning.Components.Pages
{
    public partial class MovieSeatBooking : ComponentBase
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("initializeSeats");
            }
        }
    }
}