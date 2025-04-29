[Documentation]

In the solution you will find 2 different Files, OldPhonead.cs containing the code of the implementation and UnitTests.cs containing unit tests.
To call the class you can do Phone.OldPhonePad("<your string of numbers>"), for example Phone.OldPhonePad(“8 88777444666*664#”) will output TURING

The code is done so the keys can cycle, so for example, typing 4 times the key '3', will return 'D' as it goes 'D'x1->'E'x2->'F'x3->'D'x4
UnitTest have been created to demonstrate that backspacing and whitespacing do not create any error
Allowed characters are 1-9,* and # at the end of every string
The code will return upon finding the first '#' in the string
If any invalid character is input it will return a message showing which is the invalid character
