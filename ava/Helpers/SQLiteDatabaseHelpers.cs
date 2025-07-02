using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ava.Models;
using SQLite;

namespace ava.Helpers
{
    public class SQLiteDatabaseHelpers
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelpers(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Disciplina>().Wait();
            _conn.CreateTableAsync<Curso>().Wait();
            _conn.CreateTableAsync<Periodo>().Wait();
            _conn.CreateTableAsync<Usuario>().Wait();

        }


        //Disciplina

        public Task<int> Insert(Disciplina d)
            => _conn.InsertAsync(d);

        public Task<List<Disciplina>> Update(Disciplina d)
        {
            string sql = "UPDATE Disciplina SET DisNome=?, DisSigla=?, DisObservacoes=? WHERE DisId=?";
            return _conn.QueryAsync<Disciplina>(sql, d.DisNome, d.DisSigla, d.DisObservacoes, d.DisId);
        }

        public Task<List<Disciplina>> Delete(int id)
        {
            string sql = "DELETE FROM Disciplina WHERE DisId=?";
            return _conn.QueryAsync<Disciplina>(sql, id);
        }

        public Task<List<Disciplina>> GetAll()
            => _conn.Table<Disciplina>().ToListAsync();

        public Task<List<Disciplina>> Search(string texto)
        {
            string sql = "SELECT * FROM Disciplina WHERE DisNome LIKE ?";
            return _conn.QueryAsync<Disciplina>(sql, $"%{texto}%");
        }

        //curso
        public Task<int> Insert(Curso c)
    => _conn.InsertAsync(c);

        public Task<List<Curso>> Update(Curso c)
        {
            string sql = "UPDATE Curso SET CurNome=?, CurDescricao=?, CurCargaHoraria=?, CurNivel=?, CurPeriodo=? WHERE CurId=?";
            return _conn.QueryAsync<Curso>(sql, c.CurNome, c.CurDescricao, c.CurCargaHoraria, c.CurNivel, c.CurPeriodo, c.CurId);
        }

        public Task<List<Curso>> DeleteCurso(int id)
        {
            string sql = "DELETE FROM Curso WHERE CurId=?";
            return _conn.QueryAsync<Curso>(sql, id);
        }

        public Task<List<Curso>> GetAllCursos()
            => _conn.Table<Curso>().ToListAsync();

        public Task<List<Curso>> SearchCurso(string texto)
        {
            string sql = "SELECT * FROM Curso WHERE CurNome LIKE ?";
            return _conn.QueryAsync<Curso>(sql, $"%{texto}%");
        }


        public Task<int> Insert(Periodo p) => _conn.InsertAsync(p);

        public Task<List<Periodo>> Update(Periodo p)
        {
            string sql = "UPDATE Periodo SET PerNome=?, PerSigla=?, PerObservacoes=? WHERE PerId=?";
            return _conn.QueryAsync<Periodo>(sql, p.PerNome, p.PerSigla, p.PerObservacoes, p.PerId);
        }

        public Task<List<Periodo>> DeletePeriodo(int id)
        {
            string sql = "DELETE FROM Periodo WHERE PerId=?";
            return _conn.QueryAsync<Periodo>(sql, id);
        }

        public Task<List<Periodo>> GetAllPeriodos() => _conn.Table<Periodo>().ToListAsync();

        public Task<int> Insert(Usuario u) => _conn.InsertAsync(u);

        public Task<List<Usuario>> GetAllUsuarios() => _conn.Table<Usuario>().ToListAsync();

        public Task<List<Usuario>> UpdateUsuario(Usuario u)
        {
            string sql = "UPDATE Usuario SET UsuNome = ?, UsuSenha = ? WHERE UsuId = ?";
            return _conn.QueryAsync<Usuario>(sql, u.UsuNome, u.UsuSenha, u.UsuId);

        }

        public Task<List<Usuario>> DeleteUsuario(int id)
        {
            string sql = "DELETE FROM Usuario WHERE UsuId=?";
            return _conn.QueryAsync<Usuario>(sql, id);
        }


    }
}
