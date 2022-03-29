using System;

namespace the_debate
{
	public class Player {
	
		public Random generator = new Random();
		public double health;
		double damage;
		public string action;
		public double combo_points = 1;
		public double buff_multiplier = 1;
		public double debuff_multiplier = 1;
		
		//nastaví vlastnosti podle role - set attributes by role
		public double stats_by_role(string current_role) {

			if(current_role == "1") {
				
				this.health = 80;
				
			}
			else if(current_role == "2") {
				
				this.health = 120;
				
			}
			else {
				
				this.health = 100;
				
			}
			return health;
			
		}
		
		// výběr útoků podle rolí - picks an action by role
		public void action_pick(string team, string role, Opponent opponent, Player player, string current_team) {
		
			if(role == "1") {
			
				Console.WriteLine("1. sinister strike (deals 1-6 dmg, charges 1 combo point)");
				Console.WriteLine("2. combo (deals 4-10 dmg multiplied by number of combo points)");
				action = Console.ReadLine();
				if(action == "1") {
					
					this.sinister_strike(team, current_team, opponent, player);
					
				}
				else if(action == "2") {
					
					this.combo(team, current_team, combo_points, opponent, player);
					
				}
			}
			else if(role == "2") {
			
				Console.WriteLine("1. buff (you dmg multiplier increase by 0.5)");
				Console.WriteLine("2. unstable (deals 1-10 dmg to self and opponent)");
				Console.WriteLine("3. smash (deals 1-7 dmg)");
				action = Console.ReadLine();
				if(action == "1") {
					
					this.buff(current_team);
					
				}
				else if(action == "2") {
					
					this.unstable(team, current_team, opponent, player);
					
				}
				else {
				
					this.smash(team, current_team, opponent, player);
				
				}
			}
			if(role == "3") {
			
				Console.WriteLine("1. heal (heals 4-10 hp)");
				Console.WriteLine("2. debuff (decrease opponent dmg multiplier by 0.5)");
				Console.WriteLine("3. destructive spell (deals 5-12 dmg)");
				action = Console.ReadLine();
				if(action == "1") {
					
					this.heal(current_team);
					
				}
				else if(action == "2") {
					
					this.debuff(current_team, opponent, player);
					
				}
				else {
				
					this.destructive_spell(team, current_team, opponent, player);
				
				}
			}
		}
		
		//Assasin - útok 1
		public void sinister_strike(string team, string current_team, Opponent opponent, Player player) {
			this.damage = generator.Next(1,6);
			if(current_team == team) {
				opponent.health -= damage / player.debuff_multiplier;
			}
			else {
				player.health -= damage / opponent.debuff_multiplier;
			}
			this.combo_points++;
			if(current_team == "1") {
				
				Console.WriteLine("You called the enemy a CIS WHITE MAN, dealing " + damage + " damage, also you currently have " + combo_points + " combo points");
	
			}
			else {
				
				Console.WriteLine("You DESTROYED your enemy with FACTS and LOGIC, dealing " + damage + " damage, also you currently have " + combo_points + " combo points");
			
			}
			
		}
		//Assasin - útok 2
		public double combo(string team, string current_team, double combo_points, Opponent opponent, Player player) {
			if(this.combo_points == 5) {
			
				this.combo_points -= 1;
			}
			
			this.damage = generator.Next(4,10) * this.combo_points;
			if(current_team == team) {
				opponent.health -= damage;
			}
			else {
				player.health -= damage;
			}
			if(current_team == "1") {
			
				Console.WriteLine("You called the enemy the actual fascist, dealing " + damage + " damage");
			
			}
			else if(current_team == "2") {
			
				Console.WriteLine("You pulled the vEnEzUelA argument, dealing " + damage +  " damage");
			
			}
			this.combo_points = 1;
			return combo_points;
		}
		//Warrior - útok 1
		public void buff(string current_team) {
			this.buff_multiplier += 0.5;
			if(current_team == "1") {
			
				Console.WriteLine("You played your FiRst FEmAle pResidENt card, increasing your damage " + buff_multiplier + "x");
			
			}
			else {
			
				Console.WriteLine("You have meme-ified yourself, increasing your damage " + buff_multiplier + "x");
			
			}
		
		}
		//Warrior - útok 2
		public void unstable(string team, string current_team, Opponent opponent, Player player) {
			this.damage = generator.Next(1, 10) * this.buff_multiplier;
			if(current_team == team) {
				opponent.health -= damage / player.debuff_multiplier;
				player.health -= damage / opponent.debuff_multiplier;
			}
			else {
				player.health -= damage / opponent.debuff_multiplier;
				opponent.health -= damage / player.debuff_multiplier;
			}
			if(current_team == "1") {
			
				Console.WriteLine("You made a somewhat releveant pop culture reference, dealing " + damage + " damage to self and your enemy");
			
			}
			else if(current_team == "2") {
			
				Console.WriteLine("You grabbed yo enemy by the pussy, dealing " + damage + " damage to self and your enemy");
			
			}
		
		}
		//Warrior - útok 3
		public void smash(string team, string current_team, Opponent opponent, Player player) {
			this.damage = generator.Next(1, 7) * this.buff_multiplier;
			if(current_team == team) {
				opponent.health -= damage / player.debuff_multiplier;
			}
			else {
				player.health -= damage / opponent.debuff_multiplier;
			}
			if(current_team == "1") {
			
				Console.WriteLine("You said something typical to hillary, idk she isnt that iconic, dealing " + damage + " damage");
			
			}
			else if(current_team == "2") {
			
				Console.WriteLine("You singlehandedly MADE 'MURICA GREAT AGAIN, dealing " + damage + " damage");
			
			}
		
		}
		//Mage - útok 1
		public void heal(string current_team) {
			this.health += generator.Next(4, 10);
			if(current_team == "1") {
			
				Console.WriteLine("You sniffed, restoring your health to " + health);
			
			}
			else if(current_team == "2") {
			
				Console.WriteLine("You call upon the ancient order of the consiencous(whatever that means), restoring health your health to " + health);
			
			}
		
		}
		//Mage - útok 2
		public void debuff(string current_team, Opponent opponent, Player player) {
			this.debuff_multiplier += 0.5;
			
			if(current_team == "1") {
			
				Console.WriteLine("You used the curse of \"PURE IDEOLOGY\", decreasing your opponent's damage " + debuff_multiplier + "x");
			
			}
			else if(current_team == "2") {
			
				Console.WriteLine("You used the curse of \"The post-modern neo-marxist\", decreasing your opponent's damage " + debuff_multiplier + "x");
			
			}
		
		}
		//Mage - útok 3
		public void destructive_spell(string team, string current_team, Opponent opponent, Player player) {
			this.damage = generator.Next(5, 12);
			if(current_team == team) {
				opponent.health -= damage / player.debuff_multiplier;
			}
			else {
				player.health -= damage / opponent.debuff_multiplier;
			}
			if(current_team == "1") {
			
				Console.WriteLine("You breadpilled your opponent, dealing " + damage + " damage");
			
			}
			else if(current_team == "2") {
			
				Console.WriteLine("You used an 80 year old children's tale to convey a very DEEp message, dealing " + damage + " damage");
			
			}
		
		}
	}
		
	public class Opponent : Player{
		int behaviour;
		
		// výběr útoků podle rolí
		public void action_pick(string team, string current_team, string current_role, Opponent opponent, Player player) {
			behaviour = base.generator.Next(1,3);
			if(current_role == "1") {
			
				if(behaviour == 1) {
					
					this.sinister_strike(team, current_team, opponent, player);
					
				}
				else if(behaviour == 2) {
					
					this.combo(team, current_team, combo_points, opponent, player);
					
				}
			}
			else if(current_role == "2") {
			
				if(behaviour == 1) {
					
					this.buff(current_team);
					
				}
				else if(behaviour == 2) {
					
					this.unstable(team, current_team, opponent, player);
					
				}
				else {
				
					this.smash(team, current_team, opponent, player);
				
				}
			}
			if(current_role == "3") {
			
				if(behaviour == 1) {
					
					this.heal(team);
					
				}
				else if(behaviour == 2) {
					
					this.debuff(current_team, opponent, player);
					
				}
				else {
				
					this.destructive_spell(team, current_team, opponent, player);
				
				}
			}
		}
	
	}

	class Program {
		
		//základní nastavení
		public static void Setup(out string team, out string role, out string enemy_role, out string enemy_team) {

			//výběr týmu
			
			do {
			
			Console.WriteLine("					Choose your team: 1. left, 2. right");
			
			team = Console.ReadLine();
			
			} while(team != "1" & team != "2");
			
			//výběr role
			do {
			
				if(team == "1") {
			
					Console.WriteLine("Choose your class: 1. Social Justice Wanker (assasin), 2. Hillary Clinton (warrior), 3. Slavoj Žižek (mage)");
			
				}
				else {
			
					Console.WriteLine("Choose your class: 1. Benny Shapiro (assasin), 2. D.J. Trump (warrior), 3. J.B.Peterson (mage)");
			
				}
				
				role = Console.ReadLine();
			
			} while(role != "1" & role != "2" & role != "3");
			
			//výběr protivníka
			do {
				if(team == "1") {
					
					Console.WriteLine("Choose your opponent: 1. Benny Shapiro (assasin), 2. D.J. Trump (warrior), 3. J.B.Peterson (mage)");
				
				}
				else {
				
					Console.WriteLine("Choose your opponent: 1. Social Justice Wanker (assasin), 2. Hillary Clinton (warrior), 3. Slavoj Žižek (mage)");
				
				}
			
				enemy_role = Console.ReadLine();
				
			} while(enemy_role != "1" & enemy_role != "2" & enemy_role != "3");
			
			if(team == "1") {
			
				enemy_team = "2";
			
			}
			else {
			
				enemy_team = "1";
			
			}
			Console.Clear();
		}
		
		public static void Fight(Opponent opponent, Player player, string team, string role, string current_team, string current_role, string enemy_team, string enemy_role) {
		
			do {
				current_team = team;
				current_role = role;
				Console.WriteLine("Player:");
				player.action_pick(team, role, opponent, player, current_team);
				current_team = enemy_team;
				current_role = enemy_role;
				Console.WriteLine();
				Console.WriteLine("Opponent:");
				opponent.action_pick(team, current_team, current_role, opponent, player);
				Console.WriteLine();
				Console.WriteLine("Your health: " + player.health + " Opponent health: " + opponent.health);
				Console.ReadKey();
				Console.Clear();
				
			} while(player.health >= 0 & opponent.health >= 0);
			
			Console.WriteLine();
			
			if(player.health <= 0) {
				
				Console.WriteLine("You have humiliated yourself publicly, congrats!");
			
			}
			else if(opponent.health <= 0) {
			
				Console.WriteLine("You have managed to speak louder than your opponent, winning the debate!!");
			
			}
			else if(opponent.health <= 0 & player.health <= 0) {
			
				Console.WriteLine("idk what just happene");
			
			}
		
		}
		
		public static void Main(string[] args)
		{
			string title = @"




               			.-----..-.              .-.      .-.          .-.        
               			`-. .-': :              : :      : :         .' `.       
                 	  	  : :  : `-.  .--.    .-' : .--. : `-.  .--. `. .'.--.   
                 	  	  : :  : .. :' '_.'  ' .; :' '_.'' .; :' .; ; : :' '_.'  
                 	  	  :_;  :_;:_;`.__.'  `.__.'`.__.'`.__.'`.__,_;:_;`.__.'  
                                                         
                                                         

                                               
                                                         

														";
			Console.WriteLine(title);
			Console.WriteLine();
			string team;
			string role;
			string enemy_role;
			string enemy_team;
			//team a role která momentálně hraje
			string current_team;
			string current_role;
			Program.Setup(out team, out role, out enemy_role, out enemy_team);
			Player player = new Player();
			current_role = role;
			current_team = team;
			player.stats_by_role(current_role);
			Opponent opponent = new Opponent();
			current_role = enemy_role;
			opponent.stats_by_role(current_role);
			Program.Fight(opponent, player, team, role, current_team, current_role, enemy_team, enemy_role);
			
			Console.ReadKey(true);
		}
	}
}