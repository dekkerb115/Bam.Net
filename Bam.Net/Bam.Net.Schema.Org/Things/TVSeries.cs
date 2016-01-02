/*
	Copyright © Bryan Apellanes 2015  
*/
using System;

namespace Bam.Net.Schema.Org
{
	///<summary>Series dedicated to TV broadcast and associated online delivery.</summary>
	public class TVSeries: Series
	{
		///<summary>An actor, e.g. in tv, radio, movie, video games etc. Actors can be associated with individual items or with a series, episode, clip. Supersedes actors.</summary>
		public Person Actor {get; set;}
		///<summary>A director of e.g. tv, radio, movie, video games etc. content. Directors can be associated with individual items or with a series, episode, clip. Supersedes directors.</summary>
		public Person Director {get; set;}
		///<summary>An episode of a tv, radio or game media within a series or season. Supersedes episodes.</summary>
		public Episode Episode {get; set;}
		///<summary>The composer of the soundtrack.</summary>
		public ThisOrThat<Person , MusicGroup> MusicBy {get; set;}
		///<summary>The number of episodes in this season or series.</summary>
		public Number NumberOfEpisodes {get; set;}
		///<summary>The number of seasons in this series.</summary>
		public Number NumberOfSeasons {get; set;}
		///<summary>The production company or studio responsible for the item e.g. series, video game, episode etc.</summary>
		public Organization ProductionCompany {get; set;}
		///<summary>A season in a media series. Supersedes seasons.</summary>
		public Season Season {get; set;}
		///<summary>The trailer of a movie or tv/radio series, season, episode, etc.</summary>
		public VideoObject Trailer {get; set;}
	}
}