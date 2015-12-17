/*
 * Copyright (C) 2015 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Mainmenu events.
public class MainMenuEvents : MonoBehaviour
{
	public float fadeSpeed = 1.5f; 
	public Image mFader;
	bool toBlack = false;
	bool toClear = true;

	void Start() {
		mFader.color = Color.black;
		mFader.gameObject.SetActive(true);
		toClear = true;
	}

	void Update() {
		if (toBlack) {
			FadeToBlack();
		}
		else if (toClear) {
			FadeToClear();
		}
	}
	public void Play ()
	{
		Debug.Log ("Playing!!");
		toBlack = true;
		// Make sure the texture is enabled.
		mFader.gameObject.SetActive(true);
		
		// Start fading towards black.
		FadeToBlack();

		FadeController fader = gameObject.GetComponentInChildren<FadeController>();
		if (fader != null) {
			fader.FadeToLevel(()=>{Application.LoadLevel("GameScene");});
		}
		else {
			Application.LoadLevel("GameScene");
		}
		

	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and black.
		mFader.color = Color.Lerp(mFader.color, Color.clear, fadeSpeed * Time.deltaTime);
		// If the screen is almost black...
		if(mFader.color.a <= 0.05f) {

			toClear = false;
			mFader.gameObject.SetActive(false);
			
		}
	}

	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		mFader.color = Color.Lerp(mFader.color, Color.black, fadeSpeed * Time.deltaTime);
		// If the screen is almost black...
		if(mFader.color.a >= 0.95f) {
			// ... reload the level.
			toBlack = false;

		}
	}


}
