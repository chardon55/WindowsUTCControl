# WindowsUTCControl
A library for Windows to change UTC time detection of BIOS time

## Usage

1. Use the namespace
```csharp
using WindowsUTCControl;
```

2. Instantiate a controller
```csharp
var controller = new UTCController();
```

### Get current status

```csharp
bool state = controller.IsEnabled;

Console.WriteLine(state); // "False" for most Windows which have never been configured.
```

### Set status

```csharp
// --- Enable
controller.IsEnable = true;
// Or
controller.Enable();

// --- Disable
controller.IsEnable = false;
// Or
controller.Disable();
```
