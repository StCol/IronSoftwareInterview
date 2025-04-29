namespace PhonePadUnitTesting
{
    public class UnitTests
    {
        /*
         README:
        Here are the unit tests for the program. There are 6 use cases using country names:
        1. 3 Country Names that should be correctly spelled
        2. 2 Country Names that have few backspaces
        3. Country Name with multiple backsapces at the beggining to show it does not break with Index out Of Bounds
        4. Country Name where everything is deleted i.e. Count(*) > Count(Letters) -> Should be empty
        5. Country Name beginning with multiple spaces
        6. Keys are made to cycle if pressed multiple times with no pause. They will cylce over and over
        7. Test for invalid characters (anything outside 1-9,* and #)
        */
        [Fact]
        public void countryNamesWithNoAsterisk()
        {
            //Basic tests with country names
            Assert.Equal("PAPUA NEW GUINEA", Phone.OldPhonePad("727882066339048844466332#"));
            Assert.Equal("HANSEATIC REPUBLICS", Phone.OldPhonePad("4426677773328444222077733788225554442227777#"));
            Assert.Equal("SAINT LUCIA", Phone.OldPhonePad("777724446680555882224442#"));
        }

        [Fact]
        public void countryNamesWithAsterisks()
        {
            //Tests to showcase '*' deletion is cnosistent
            Assert.Equal("COTE D'IVORE", Phone.OldPhonePad("2226668333*3303444*1144488866677733#"));
            Assert.Equal("PHILIPPINES", Phone.OldPhonePad("744 4466**4445554447 7444666*66337777#"));
        }
        [Fact]
        public void countryNamesBeginMultipleDeletions()
        {
            //Tests to try and break index out of bounds by beginning with multiple asterisks
            Assert.Equal("COLOMBIA", Phone.OldPhonePad("*********222666555666 6224442#"));
            Assert.Equal("ESTONIA", Phone.OldPhonePad("*****3377778666 664442#"));
        }
        [Fact]
        public void moreDeletionsThanLetters()
        {
            //Tests to try and break index out of bounds by having more * than letters, should return empty
            Assert.Equal("", Phone.OldPhonePad("2 225458888 88 99*****77788*************#"));
            Assert.Equal("", Phone.OldPhonePad("**88889965551 11 111 663*********** 5**#"));
        }

        [Fact]
        public void countrNamesBeginWithMultipleSpaces()
        {
            //Tests with additional spaces at the beginning
            Assert.Equal("     FINLAND", Phone.OldPhonePad("0 0 0 0 0333444665552663#"));
            Assert.Equal("   ESTONIA", Phone.OldPhonePad("0 0 03377778666 664442#"));
        }
        
        [Fact]
        public void countrNamesCyclingLetter()
        {
            //Implementation has a cycling mechanism if pressed more than the amount of characters in the key e.g. 3333 -> d->e->f->d - D will be chosen 
            Assert.Equal("GERMANY", Phone.OldPhonePad("44443377777776222266999#"));
            Assert.Equal("INDONESIA", Phone.OldPhonePad("44466333355*666666 663377775*4442#"));
        }
        public void invalidInput()
        {
            //Implementation has a cycling mechanism if pressed more than the amount of characters in the key e.g. 3333 -> d->e->f->d - D will be chosen 
            Assert.Equal("There is a bad character in the input!: T", Phone.OldPhonePad("44555252*9865T978952#"));
            Assert.Equal("There is a bad character in the input!: M", Phone.OldPhonePad("***878555267541**M878888"));
        }



    }
}