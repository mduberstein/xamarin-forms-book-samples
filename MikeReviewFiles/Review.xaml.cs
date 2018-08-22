using System;
using System.ComponentModel;
using System.Collections.Generic;

public class LittleViewModel : INotifedPropertyChanged{
	string name;
	bool isValid;
	int languageIndex = -1;
	string[] languages = { "C#", "F#" };

	public string Name {
		set {
			if(name != value){
				name = value;
				OnPropertyChanged(nameof(Name));
				TestIsValid();
			}
		}
		get { return name; }
	}

	public int LanguageIndex {
		set {
			if(languageIndex != value){
				languageIndex = value;
				OnPropertyChanged(nameof(LanguageIndex));
				if(languageIndex >= 0 && languageIndex < languages.Length){
					Language = languages[languageIndex];
					OnPropertyChanged(nameof(Language));
				}
				TestIsValid();
			}
		}
	}

	public string Language { get; private set; }

	public bool IsValid { 
		private set {
			if(isValid != value){
				isValid = value;
				OnPropertyChanged(nameof(IsValid));
			}
		}
		get { return isValid; }  
	}

	void TestIsValid (){
		IsValid = !string.IsNullOrWhiteSpace(Name) && 
		          !string.IsNullOrWhiteSpace(Language);
	}
	public event PropertyChangedEventHandler PropertyChanged;

	void  OnPropertyChanged(string propertyName) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}