class Score
{  
     public int score = 0;
     
     public int gotGem(int score)
     {
          return score += 100;
     }

     public int gotRock(int score)
     {
          return score -= 50;
     }
}