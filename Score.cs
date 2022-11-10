class Score
{  
     public int score = 0;
     
     public void gotGem(int score)
     {
          score += 100;
     }

     public void gotRock(int score)
     {
          score -= 50;
     }
}