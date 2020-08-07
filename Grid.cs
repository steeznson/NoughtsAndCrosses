using System;
using System.Collections.Generic;

namespace Game{
    class Grid{
        private List<string> row0;
        private List<string> row1;
        private List<string> row2;
        
        public List<string> getRow0() {
            return this.row0;
        }
        public void setRow0(List<string> newRow) {
            this.row0 = newRow;
        }
        public List<string> getRow1() {
            return this.row1;
        }
        public void setRow1(List<string> newRow) {
            this.row1 = newRow;
        }
        public List<string> getRow2() {
            return this.row2;
        }
        public void setRow2(List<string> newRow) {
            this.row2 = newRow;
        }
    }
}
