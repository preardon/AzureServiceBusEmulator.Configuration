## ASB Configuration Example

This sample is made up of 2 parts
  - **The Receiver Console** : An application that listens to commands and emits Events
  - **The Sender Console** : An applications that sends commands

When running the worker locally it will generate a Config file for to be loaded into the ASB Emulator

### Instructions

1. Run ASBExample.ReceiverConsole in Debug
1. Run Docker Compose

    ```Bash
      podman compose -f .\Docker-Compose.yml up -d
    ```
1. Run both samples, they will now work and communicate using the Local ASB Emulator