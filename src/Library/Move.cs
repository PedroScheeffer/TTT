namespace TTT{
    public class Move
    {
        private int valueX; 
        private int valueY;
        public Move(int x, int y){
            valueX = x;
            valueY = y;
        }
        public int GetValueX(){
            return valueX;
        }
        public int GetValueY(){
            return valueY;
        }
        public bool isValid(){
            bool xValid = (valueX >= 0 && valueX < 3);
            bool yValid = (valueY >= 0 && valueY < 3);
            return  xValid && yValid;
        }
        override public string ToString(){
            return valueX + " " + valueY;
        }
    }
}