using UnityEngine;
using System.Collections;
using System.Net;

public enum LanguageUID
{
    ENGLISH,
    PORTUGUESE
}

public static class GameConfig {

    public static LanguageUID Language = LanguageUID.PORTUGUESE;

    // Controle de volume de som
    public static SoundManager soundManager  = new SoundManager();//gerenciador de aldio
    
    // Variaveis do jogador
    public static int score;//pontuação da partifa atual
    public static int highScore;//pontuação maxima alcançada

    public static int playerDeaths;//quantas vezes o jogador moreu

    public static int enemiesKills;//quantos inimigos ja foram derotados
    public static int initializedSessions;// quantas vezes o jogador logou no jogo

    public static bool isDeth;

    public static bool isPaused;
    

    // Game Jolt API ===================================

    //ID do Jogo 
    //87477 (API-Teste)

    //Chave Privada
    //f0c47a3322ddffc50bcb69d1c7d03393 (API-Teste)

    //Tabelas de Placares
    public static int highScore_id = 90910;//90910 (high score) 

    //Varieveis de conecção
    public static bool isSignedIn;
    public static bool isInternetConnection;

    //Verifica se o site "http://gamejolt.com" esta disponivel para conexão
    public static bool checkForInternetConnection()
    {
        System.Net.WebClient client;
        System.IO.Stream stream;
        try
        {
            client = new System.Net.WebClient();
            stream = client.OpenRead("http://gamejolt.com");
            return true;
        }
        catch (WebException e)
        {
            return false;
        }
    }
    
}
