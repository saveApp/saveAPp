﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PassingData
{
	public partial class MainPage : ContentPage
	{
		private List<NewsModel> mItems;
		// CHECK IF LOGGED IN OR NOT
		bool logged = true;
		static string uri = "http://104.199.155.15/api/v2/db/_table/quest";

		string responseAsString;

		public MainPage ()
		{
			InitializeComponent ();

			var buttonAccount = new ToolbarItem
			{
				Text = "Account",
				Order = ToolbarItemOrder.Secondary,
				Priority = 0,
			};
			buttonAccount.Clicked += (object sender, System.EventArgs e) =>
				{
					this.DisplayAlert("Selected!", "Account", "OK");
				};

			var buttonHistory = new ToolbarItem
			{
				Text = "History",
				Order = ToolbarItemOrder.Secondary,
				Priority = 1
			};
			buttonHistory.Clicked += (object sender, System.EventArgs e) =>
				{
					this.DisplayAlert("Selected!", "History", "OK");
				};

			var buttonLogOut = new ToolbarItem
			{
				Text = "Log Out",
				Order = ToolbarItemOrder.Secondary,
				Priority = 2
			};
			buttonLogOut.Clicked += (object sender, System.EventArgs e) =>
				{
					logged = false;
					this.DisplayAlert("Selected!", "LogOut", "OK");
				};

			var buttonLogIn = new ToolbarItem
			{
				Text = "Log In",
				Order = ToolbarItemOrder.Secondary,
				Priority = 0
			};
			buttonLogIn.Clicked += (object sender, System.EventArgs e) =>
				{
					logged = true;
					this.DisplayAlert("Selected!", "LogIn", "OK");
				};

			if (logged){
				ToolbarItems.Add(buttonAccount);
				ToolbarItems.Add(buttonHistory);
				ToolbarItems.Add(buttonLogOut);
			}
			else {
				ToolbarItems.Add(buttonLogIn);
			}

			String JSONString = "\"resource\": [{\"id\": 1,\"newsTitle\": \"BRRRR Cikepeh\",\"newsContent\": \"College is usually a student’s first experience living away from home. So it can be all too easy for your student to spend any student loan or other money as soon as it arrives, without giving much thought to expenses like rent, utilities, cell phone bills, and food that need to be paid throughout the year. Living within one’s means is a learned skill. But there are basic tools, like a cash management account and reward credit cards, that make it easier to create a budget, provide more flexibility in managing day-to-day expenses, and help students live independently. For parents, these same tools offer a system of checks and balances and a convenient way to provide financial support, while simplifying tax reporting. Most importantly, they lay the groundwork for your child’s financial independence.\",\"newsURL\": \"http://www.forbes.com/sites/fidelity/2015/09/10/four-ways-to-help-students-and-parents-manage-money/#590c72081ce7\",\"newsIMGURL\": \"http://www.forbes.com/sites/fidelity/2015/09/10/four-ways-to-help-students-and-parents-manage-money/#590c72081ce7\"},{\"id\": 2,\"newsTitle\": \"Mau kaya?\",\"newsContent\": \"ikut MLM aja.\",\"newsURL\": \"http://www.forbes.com/sites/fidelity/2015/09/10/four-ways-to-help-students-and-parents-manage-money/#590c72081ce7\",\"newsIMGURL\": \"http://www.forbes.com/sites/fidelity/2015/09/10/four-ways-to-help-students-and-parents-manage-money/#590c72081ce7\"}]";
			JSONString = JSONString.TrimEnd('}').TrimStart('{').Substring(11);
			mItems = JsonConvert.DeserializeObject<List<NewsModel>>(JSONString);
			listView.ItemsSource = mItems;
			listView.ItemSelected += (sender, e) =>{
				//DisplayAlert("Item selected!", (e.SelectedItem as NewsModel).newsContent, "hehe");
				DisplayAlert("Item selected!", responseAsString, "hehe");
			};


		}
		async void toCalculate(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CalculatePage());
		}


	}
}
