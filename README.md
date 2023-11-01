# Assets

INSTALLATION INSTRUCTIONS

It is very important to use the specified versions of each program - ml-agents is very finicky with the versions and will not work with other python versions
i. Downloads:
  1. Unity hub - https://unity.com/download
  2. Unity version 2022.3.12f1 - (from within Unity Hub, it should be the latest version)
  3. Python 3.9.13 - https://www.python.org/downloads/release/python-3913/

ii. Preparing unity project
  1. Open up Unity version 2022.3.12f1 --> Click "New Project" --> name project and ensure that "2D" is selected under templates --> Click "Create Project"
  2. Once project loads, click on "Window-->Package Manager" from the bar at the top of the screen.
  3. From the package manager screen, click the button "Packages:" which is beside the "+" which is near the top left of the window. Change this option to "Unity Registry"
  4. In the search bar, search up "ML agents" and install this package.

iii. Preparing ML-agents python library
  1. From the command line, navigate to your Unity project file directory. Once there, create a python virtual environment using the command "py -3.9 -m venv venv".
  2. upgrade pip: "python -m pip install --upgrade pip"
  3.  install pytorch: "pip3 install torch torchvision torchaudio"
  4.  install mlagents library: "pip install mlagents"
  5.  install protobuff: "pip install protobuf==3.20.3"
  6.  install onxx: "python -m pip install onxx"
  7.  I had an error with the package "packaging". install it with: "pip3 install packaging" if necessary
  8.  To test all installed correctly, first start your venv by running the "Activate" script which is found at \PROJECT_ROOT\venv\Scripts\activate.
  9.  Then, type: "mlagents-learn --help". A list of commands should pop up. If not, there is some error with the installation.

With these installations, you should be ready to import all of the data from this repo into your unity project!

iv. Final steps
  1. Delete the Assets folder in your current Unity project directory.
  2. Clone this new Assets folder into your Unity project directory.
  3. Move the file "TagManager.asset", which is included in this repo, into the "ProjectSettings" folder which is found in your project directory.

v. Running ML agents
  1. To run ml-agents, ensure that you have activated your venv.
  2. To begin training, type: "mlagents-learn --run-id=test_name"
  3. If the run-id "test_name" already exists, then you will get an error. You can use the flag --force to overwrite the previous data and start fresh with the same name. Be careful that you are not overwriting important data when you use this flag.
  4. You can use the flag --resume to resume a previously trained model.
  5. You can use an optional argument specifying the configuration file to be used. This would look like: "mlagents-learn mario_config.yaml --run-id=test_name". This yaml file must be located at "\PROJECT_ROOT\venv\Scripts\"
