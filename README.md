## Count Counter
This is a simple counter application that supports incrementing a counter value. Since it uses BigInteger there is no real limit to how far it can count, but *only* 12 606 characters are able to be seen in the GUI.  

### Features
- Increment a counter value and view it in a GUI.
    - No real limit to how far the counter can go (but limited in the GUI display).
- Automatically saves when quitting, but also allows manual saving.
- Can reset the counter value.

### Installation
1. Download the latest build from the [Releases](https://github.com/Caramajau/count-counter/releases) page.
2. Extract the downloaded ZIP file to a folder of your choice.
3. Run the `CountCounter.exe` file to start the application. See [Instructions](#instructions) for usage details.

### Instructions
#### General instructions
You can interact with the GUI through left-clicking the buttons. It should be intuitive, but below is an explanation of each button:
- Current Counter Value: Increases the counter value by 1. (The increment button)
- Quit: Exits the application and saves the counter value.
- Reset: Resets the counter value to 0.
- Save: Manually saves the current counter value.
- -1: Decreases the counter value by 1.

#### Keyboard instructions
In addition to mouse controls, keyboard navigation is also supported.
- **WASD** to move between the buttons on the GUI.
- **ENTER** to trigger the selected button.

#### Controller instructions
Additionally, controller support is also available. Typical controls are used:
- **Left stick or D-pad** to move between the buttons on the GUI.
- **Confirm button** to trigger the selected button. (A button for Xbox and Switch, while Cross button for Playstation)

NOTE: Only a DUALSHOCK&reg;4 Wireless Controller and a Nintendo Switch&trade; Pro Controller have been tested, but other controllers should work as well.

#### Additional navigation information
By default, the increment button is selected.

NOTE: When switching between the increment button and the buttons to the side, the **Save** button will first be selected.

### Implementation details
The project is built using ```Unity 6000.0.40f1``` and uses BigInteger for the counter value.

### Limitations
- The GUI can only display up to 12 606 characters of the counter value. See the [maximum_counter_value_example](./maximum_counter_value_example.txt) for an example of the length limitation. 
    - NOTE: You can still achieve a greater count than in the example by counting so that all numbers are exclusively 9s, but beyond that will not be displayed correctly in the GUI.
- The application supports incrementing and decrementing the counter by 1. Other operations, like multiplying, etc., are not supported.

### Additional notes
- If you have any suggestions or feature requests, feel free to open an issue on the [Issues](https://github.com/Caramajau/count-counter/issues) page.
