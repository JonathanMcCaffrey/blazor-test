# Razor

Razor is a markup syntax for embedding code into a web page.


Uses classical HTML syntax.

```razor
<title>Counter</title>
```

Additional logic is added to the bottom page in csharp.

```razor
@code {
    // Your logic
}
```

Syntax for adding a variable into the web component.

```razor
<title>@Title</title>

@code {
    [Parameter]
    public string Title { get; set; } = "Counter";
}
```

Syntax for adding a clickable function.

```razor
<button @onclick="IncrementCounter">Increment - @currentCount</button>

@code {
    private int currentCount = 0;
    private void IncrementCounter() {
        currentCount++;
    }
}
```

CSS can be adjusted based on this variable syntax.

```razor
<button class="@buttonState" @onclick="Click">Click Me</button>

@code {
    private string buttonState = "not-clicked";
    void Click() {
        buttonState = "clicked";
    }
}
```

Lambda's can be used inline with the CSS.

```razor
<button disabled="@isClicked" @onclick="(()=>isClicked=true)">Click Me</button>
```

Sharing HTML input with the C# code.

```razor
<div>
<input type="string" @blind="@name" @onkeypress="KeyHandler" @onkeypress:preventDefault="true"/>
Submitted name: @submittedName
</div>

@code {
    private string name = "";
    private string submittedName = "";

    private void KeyHandler(KeyboardEventArgs event) {
        if(event.Key == "Enter") {
            submittedName = name;
        }
    }
}
```